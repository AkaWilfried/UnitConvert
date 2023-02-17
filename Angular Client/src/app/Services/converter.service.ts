import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RateInput, Rates } from '../Model/entities';

@Injectable({
  providedIn: 'root'
})
export class ConverterService {
  header: HttpHeaders;
  private baseUrl = environment.apiURL;
  constructor(private http: HttpClient) { 
    this.header = new HttpHeaders();
    this.header.set('Content-Type', 'application/json');
  }

  getRates(): Observable<any> {
    return this.http.get<Rates[]>(this.baseUrl + '/rates');
  }

  postconverter(rateInput: RateInput): Observable<any> {
    return this.http.post<number>(this.baseUrl + '/convert', rateInput);
  }
}
