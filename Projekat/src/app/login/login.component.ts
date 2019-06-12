import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { LoginService } from '../login.service';
import { AdminScheduleComponent } from '../admin-schedule/admin-schedule.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [LoginService]

})
export class LoginComponent {

  message: string;


  loginForm = this.fb.group({
    username: ['', Validators.required],
    password: ['', Validators.required],
  });

  constructor(public authService: LoginService, public router: Router, private fb: FormBuilder) {
    this.setMessage();
  }

  setMessage() {
    this.message = 'Logged ' + (this.authService.isLoggedIn ? 'in' : 'out - make you profile');
    
  }

  login() {
    this.authService.login(this.loginForm.value).subscribe((data) => {
      if(data === "Admin"){
        this.router.navigate(["admin"]);
      }
      else if (data === "AppUser") {
        this.router.navigate(["user"]);
      }
      else{
       // this.router.navigate(["unauthorizedUser", "logIn"]);
        this.message = "Pogresan email ili loznika";
      }
    });
  }

  logout() {
    this.authService.logout();
    
    this.setMessage();
  }
}