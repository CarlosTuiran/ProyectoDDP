import { Component, OnInit } from '@angular/core';
import { ConveniosService } from './convenios.service';

@Component({
  selector: 'app-convenios',
  templateUrl: './convenios.component.html',
  styleUrls: ['./convenios.component.css']
})
export class ConveniosComponent implements OnInit {

  convenios: IConvenio[];
  constructor(private conveniosService: ConveniosService) { }

  ngOnInit() {
    this.conveniosService.getConvenios()
      .subscribe(convenios => this.convenios = convenios,
        error => console.error(error));
  }

}
export interface IConvenio {
  fecha: Date;
  iD_Empresa: number;
  estado: string;
}
