import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm(){
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      role: [null, Validators.required],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20), Validators.pattern('^(?=.{6})(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])')]],
      confirmPassword: ['', Validators.required]
    });
  }

  register(){
    this.authService.register(this.registerForm.value).subscribe(() => {
      alert("User has been successfully registered");
      this.router.navigate(['/home']);
    }, error => {
      alert(error.status);
    });
  }

}
