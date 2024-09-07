import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { UsuarioService } from '../servicios/usuario.service';
import { CompartidoService } from '../../compartido/compartido.service'
import { Login } from '../interfaces/Login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  formLogin: FormGroup;
  ocultarPassword: boolean = true;
  mostratLoading: boolean = false;

  constructor(private fb: FormBuilder,
              private router: Router,
              private usuarioServicio: UsuarioService,
              private compartidoServicio: CompartidoService){
    this.formLogin = this.fb.group({
      username: ['',Validators.required],
      password: ['', Validators.required]
    });
  }

  iniciarSesion(){
    this.mostratLoading = true;
    const request: Login = {
      username: this.formLogin.value.username,
      password: this.formLogin.value.password
    };
    this.usuarioServicio.iniciarSesion(request).subscribe({
      next: (response) => {
        this.compartidoServicio.guardarSesion(response);
        this.router.navigate(['layout']);
      },
      complete: () => {
        this.mostratLoading = false;
      },
      error: (error) => {
        this.compartidoServicio.mostrarAlerta(error.error, 'Error!');
        this.mostratLoading = false;
      }
    });

  }
}
