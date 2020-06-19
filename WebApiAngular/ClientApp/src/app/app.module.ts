import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AdminsComponent } from './admins/admins.component';
import { AdminsService } from './admins/admins.service';
import { EstudiantesComponent } from './estudiantes/estudiantes.component';
import { DocentesComponent } from './docentes/docentes.component';
import { EmpresasComponent } from './empresas/empresas.component';
import { SolicitudesComponent } from './solicitudes/solicitudes.component';
import { PracticasComponent } from './practicas/practicas.component';
import { ConveniosComponent } from './convenios/convenios.component';
import { EstudiantesService } from './estudiantes/estudiantes.service';
import { DocentesService } from './docentes/docentes.service';
import { EmpresasService } from './empresas/empresas.service';
import { SolicitudesService } from './solicitudes/solicitudes.service';
import { PracticasService } from './practicas/practicas.service';
import { ConveniosService } from './convenios/convenios.service';
import { AdminsFormComponent } from './admins/admins-form/admins-form.component';
import { ConveniosFormComponent } from './convenios/convenios-form/convenios-form.component';
import { EstudiantesFormComponent } from './estudiantes/estudiantes-form/estudiantes-form.component';
import { DocentesFormComponent } from './docentes/docentes-form/docentes-form.component';
import { EmpresasFormComponent } from './empresas/empresas-form/empresas-form.component';
import { SolicitudesFormComponent } from './solicitudes/solicitudes-form/solicitudes-form.component';
import { PracticasFormComponent } from './practicas/practicas-form/practicas-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AdminsComponent,
    EstudiantesComponent,
    DocentesComponent,
    EmpresasComponent,
    SolicitudesComponent,
    PracticasComponent,
    ConveniosComponent,
    AdminsFormComponent,
    ConveniosFormComponent,
    EstudiantesFormComponent,
    DocentesFormComponent,
    EmpresasFormComponent,
    SolicitudesFormComponent,
    PracticasFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([ //Routes Aca
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'admins', component: AdminsComponent },
      { path: 'estudiantes', component: EstudiantesComponent },
      { path: 'docentes', component: DocentesComponent },
      { path: 'empresas', component: EmpresasComponent },
      { path: 'solicitudes', component: SolicitudesComponent },
      { path: 'practicas', component: PracticasComponent },
      { path: 'convenios', component: ConveniosComponent },
      { path: 'admins-crear', component: AdminsFormComponent },
      { path: 'estudiantes-crear', component: EstudiantesFormComponent },
      { path: 'docentes-crear', component: DocentesFormComponent },
      { path: 'empresas-crear', component: EmpresasFormComponent },
      { path: 'solicitudes-crear', component: SolicitudesFormComponent },
      { path: 'practicas-crear', component: PracticasFormComponent },
      { path: 'convenios-crear', component: ConveniosFormComponent },



    ])
  ], //servicios aca
  providers: [AdminsService,
    EstudiantesService,
    DocentesService,
    EmpresasService,
    SolicitudesService,
    PracticasService,
    ConveniosService],
    bootstrap: [AppComponent]
})
export class AppModule { }
