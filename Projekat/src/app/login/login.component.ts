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
      this.setMessage();
      console.log(data);
     
    });
  }

  logout() {
    this.authService.logout();
    this.setMessage();
  }
}