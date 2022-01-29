import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = []
  public eventosFiltrados: any = []

  larguraImagem: number = 150;
  margemImagem: number = 2;
  mostrarImagem: boolean  = true;

  //#region  Filtros
  private _filtroLista: string = '';

  public get filtroLista(): string
  {
    return this._filtroLista;
  }

  public set filtroLista(value: string)
  {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): any
  {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) != -1 ||
                       evento.local.toLocaleLowerCase().indexOf(filtrarPor) != -1
    );
  }

  //#endregion

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.GetEventos();
  }

  ExibirImagem(){
    this.mostrarImagem = !this.mostrarImagem

  }

  public GetEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response =>
      {
        this.eventos = response
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );
  }
}
