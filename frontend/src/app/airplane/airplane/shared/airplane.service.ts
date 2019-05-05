import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpRequest, HttpEvent } from '@angular/common/http';
import { AvisoService } from '../../../services/aviso.service';
import { Router } from '@angular/router';
import { URL } from '../../../app.constants';

@Injectable({
  providedIn: 'root'
})
export class AirplaneService {

  constructor(private http: HttpClient,    
    private aviso: AvisoService,
    private router: Router,) { }

  get(): Observable<any> {
    return this.http.get(URL.API + "Aircraft");
  }

  post(form: any): void {
    this.http.post(URL.API + "Aircraft", form).subscribe(() => {
      this.aviso.avisar("adicionado com sucesso!" );
      this.router.navigate(["/inicio"]);
    }, 
    erro => {
      this.aviso.avisar("Ocorreu um erro ao realizar essa operação.");
    });
  }

  delete(id: string): Observable<any>  {
    return this.http.delete<any>(URL.API + "Aircraft/" + id);
  }

}
