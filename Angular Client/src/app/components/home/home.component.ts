import { Component, OnInit } from '@angular/core';
import { MessageService, SelectItem } from 'primeng/api';
import { RateInput, Rates } from 'src/app/Model/entities';
import {ConverterService} from 'src/app/Services/converter.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [MessageService]

})
export class HomeComponent implements OnInit {

  text: string;
  sensList: SelectItem[];
  sensitem: number;
  rates: Rates[];
  ratesItems: SelectItem[];
  rateinput: RateInput;
  convertresult: number;
  constructor(private messageService: MessageService, private convertservice: ConverterService) { 
    this.sensList =  [];
    this.ratesItems = [];
    this.text = 'Not choose';
    this.sensitem = 0;
    this.rateinput = new RateInput();
    this.rateinput.sens = 0;
    this.rateinput.unit = 1;
    this.rateinput.value = 0;
    this.convertresult = 0;
  }

  ngOnInit(): void {
    this.sensList = [
      { value: 0, label: 'Imperial units to Metric units'},
      { value: 1, label: 'Metric units to Imperial units'}
    ];
    this.onLoadRates();
  }

  onSensChange(): void {
    /* this.messageService.add({severity: 'info', summary: 'Information',
        detail: 'Selected: ' + this.rateinput.sens.toString()}); */
    this.rateinput.value = 0;
    this.convertresult = 0;
    this.ratesItems = [];
    if (this.rateinput.sens === 0) {
      this.rates.forEach(element => {
          this.ratesItems.push({value: element.id, label: element.unit})
      });
    } else {
      this.rates.forEach(element => {
        this.ratesItems.push({value: element.id, label: element.equivalentunit})
    });
    }

    this.onChangeFrom();
  }

  onChangeFrom(): void {
    if (!this.rateinput.unit) return;
     this.text = this.rateinput.sens === 0 ? this.rates.find(c=> c.id === this.rateinput.unit).equivalentunit
     :this.rates.find(c=> c.id === this.rateinput.unit).unit;
   
  }

  onLoadRates(): void {
    this.rates = [];
    this.convertservice.getRates().subscribe((data: Rates[]) => {
      this.rates = data;
      this.onSensChange();
    });
  }

  onConvert(): void {
    this.convertservice.postconverter(this.rateinput).subscribe((res: number) => {
      this.convertresult = +res.toFixed(2);
    })
  }

  onClear(): void {
    this.rateinput = new RateInput();
    this.rateinput.sens = 0;
    this.rateinput.unit = 1;
    this.rateinput.value = 0;
    this.convertresult = 0;
  }

}
