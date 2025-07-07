import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { InvestmentCalculatorService, InvestmentRequest, InvestmentResponse } from './investment-calculator.service';

@Component({
  selector: 'app-investment-calculator',
  templateUrl: './investment-calculator.component.html',
  styleUrls: ['./investment-calculator.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule]
})
export class InvestmentCalculatorComponent {
  request: InvestmentRequest = {
    valor: 1000,
    prazoMeses: 100
  };

  response: InvestmentResponse | null = null;
  loading = false;
  error = '';

  constructor(private investmentService: InvestmentCalculatorService) {}

  calcularInvestimento() {
    this.loading = true;
    this.error = '';
    this.response = null;
    this.investmentService.calcularInvestimento(this.request)
      .subscribe({
        next: (data) => {
          this.response = data;
          this.loading = false;
        },
        error: (error) => {
          this.error = 'Erro ao calcular investimento. Tente novamente.';
          this.loading = false;
          console.error('Erro:', error);
        }
      });
  }

  formatarMoeda(valor: number): string {
    return new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL'
    }).format(valor);
  }

  formatarData(data: string): string {
    return new Date(data).toLocaleDateString('pt-BR', {
      day: '2-digit',
      month: '2-digit',
      year: 'numeric',
      hour: '2-digit',
      minute: '2-digit'
    });
  }

  formatarPercentual(valor: number): string {
    return `${(valor * 100).toFixed(1)}%`;
  }
} 