import { Component, OnInit } from '@angular/core';
import { SolicitudesService } from './solicitudes.service';

@Component({
  selector: 'app-solicitudes',
  templateUrl: './solicitudes.component.html',
  styleUrls: ['./solicitudes.component.css']
})
export class SolicitudesComponent implements OnInit {

  solicitudes: ISolicitud[];
  constructor(private solicitudesService: SolicitudesService) { }

  ngOnInit() {
    this.solicitudesService.getSolicitudes()
      .subscribe(solicitudes => this.solicitudes = solicitudes,
        error => console.error(error));
  }

}
export interface ISolicitud {
  tipo: string;
  fecha: Date;
  iD_Solicitante: number;
  tipo_Solicitante: string;
  estado: string;
}
