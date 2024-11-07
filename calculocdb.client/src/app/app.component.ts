import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppComponent {
  public valorInicial: number | undefined = 0.1;
  public quantidadeMeses: number | undefined = 2;

  public valorBruto: number | undefined = 0.0;
  public valorLiquido: number | undefined = 0.0

  constructor(private readonly http: HttpClient, private readonly cdRef: ChangeDetectorRef) { }
  
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  postCalculoCdb() {
    this.http.post('/api/calculocdb', { valorInicial: this.valorInicial, quantidadeMeses: this.quantidadeMeses }, { headers: this.headers }).subscribe(
      {
        next: (result: any) => {
          this.valorBruto = result.valorBruto;
          this.valorLiquido = result.valorLiquido;
          this.cdRef.detectChanges();
        },
        error: (error) => {
          console.error(error);
        }
      }
    );
  }

  validarCampos(): boolean {
    return this.quantidadeMeses === undefined || this.quantidadeMeses === null || this.quantidadeMeses <= 0 ||
      this.valorInicial === undefined || this.valorInicial === null || this.valorInicial === 0;
  }

  title = 'calculocdb.client';

}
