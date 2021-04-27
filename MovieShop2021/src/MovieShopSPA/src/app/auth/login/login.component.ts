import { AuthenticationService } from './../../core/services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Login } from 'src/app/shared/models/login';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  // one- way binding
  // two-way binding

  userLogin: Login = {        //model
    email:'', password:''
  };

  invalidLogin:boolean = false;

  constructor(private authService:AuthenticationService, private router:Router) { }

  ngOnInit(): void {
    //console.log(this.userLogin)


  }


  login(){
    this.authService.login(this.userLogin).subscribe(
      (response) => {
        if (response){
          this.router.navigate(['/']);
        }
      },
      (error) => {
        if (error){
          this.invalidLogin = true;
        }
      }
    );

  }

  get twoWayInfo(){return JSON.stringify(this.login);}      // for observe 2-way binding

}
