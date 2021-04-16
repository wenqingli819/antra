import { Login } from './../../shared/models/login';
import { BehaviorSubject, Observable } from 'rxjs';
import { JwtStorageService } from './jwt-storage.service';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { User } from 'src/app/shared/models/user';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private user: User | null;

  private currentUserSubject = new BehaviorSubject<User> ({} as User);
  public currentUser = this.currentUserSubject.asObservable();

  private isAuthenticaedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this.isAuthenticaedSubject.asObservable();

  constructor(private apiService:ApiService, private jwtStorageService:JwtStorageService) { }

  login(userLogin:Login) : Observable<boolean>{
    // take username/password from login component and post it to API
    // once API returns token, store the token in local storage of the browswer
    // otherwise, return false to component, so the component can show the mesage in the UI
    return this.apiService.create('account/login', userLogin)
      .pipe(map((response: { token: string; }) => {
        if (response) {
          // save the response token to localstorage
          this.jwtStorageService.saveToken(response.token);
          this.populateUserInfo();
          return true;
        }
        return false;
      }));
  }

  logout(){
    // remove the token from local storage
    this.jwtStorageService.destroyToken();

    // setting default values to observables. component subscribers would auto get this
    this.currentUserSubject.next({} as User);

    this.isAuthenticaedSubject.next(false);

  }

  decodeToken(): User | null {
    // it will read the token from localstorage and decode it and put it in User object
    // also check the token is not expired
    const token = this.jwtStorageService.getToken();

    if(token !=null) {
      const tokenExpired = new JwtHelperService().isTokenExpired(token);
      if (tokenExpired || !token)
        return null;

      const decodedToken = new JwtHelperService().decodeToken(token);

      this.user = decodedToken;
      return this.user;
    }

    return null;
  }

  populateUserInfo(){
    if(this.jwtStorageService.getToken()){

      const decodedToken = this.decodeToken();

      if(decodedToken != null){
        this.currentUserSubject.next(decodedToken);  //fill value in observables
        this.isAuthenticaedSubject.next(true);
      }


    }
  }
}
