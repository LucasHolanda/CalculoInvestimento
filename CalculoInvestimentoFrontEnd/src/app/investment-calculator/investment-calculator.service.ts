import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

export interface InvestmentRequest {
  valor: number;
  prazoMeses: number;
}

export interface InvestmentResponse {
  prazoMeses: number;
  valorInicial: number;
  valorBruto: number;
  valorLiquido: number;
  imposto: number;
  valorImposto: number;
  valorRendimentoLiquido: number;
  valorRendimentoBruto: number;
  dataCalculo: string;
}

@Injectable({ providedIn: 'root' })
export class InvestmentCalculatorService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  calcularInvestimento(request: InvestmentRequest): Observable<InvestmentResponse> {
    return this.http.post<InvestmentResponse>(`${this.apiUrl}/api/cdb/calcular`, request);
  }
} 