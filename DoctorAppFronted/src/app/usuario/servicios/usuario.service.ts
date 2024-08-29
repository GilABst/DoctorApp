import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Login } from '../interfaces/Login';
import { Observable } from 'rxjs';
import { Sesion } from '../Interfaces/Sesion';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  baseUrl: string = environment.apiUrl + "usuario/"
  constructor(private http: HttpClient) { }

  iniciarSesion(request: Login): Observable<Sesion>{
    return this.http.post<Sesion>('${this.baseUrl}login', request);
  }
}
