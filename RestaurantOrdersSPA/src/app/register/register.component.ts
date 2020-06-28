import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20), Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[#$%^&*()=+\[\]|:'"_,.<>/? \\])(?!.*[!@;€\-ÿ])/)]],
      confirmPassword: ['', Validators.required]
    }, { validator: [this.passwordMatchValidator, this.passwordHasUsername] });
  }

  passwordMatchValidator(g: FormGroup){
    return g.get('password').value === g.get('confirmPassword').value ? null : {'passwordsMismatch': true};
  }

  passwordHasUsername(g: FormGroup){
      var pwValue = g.get('password').value;
      var unValuePattern = new RegExp(g.get('username').value);
      var hasUsernameCheck = pwValue.match(unValuePattern);
      if(hasUsernameCheck && g.get('username').dirty || hasUsernameCheck && g.get('username').touched){
        return {'containsUsername': true}
      }
      return null;
  }

  invalidPasswordField(){
    var formControl = this.registerForm.get('password');
    if((formControl.dirty || formControl.touched) && formControl.errors || formControl.dirty && this.registerForm.hasError('containsUsername')){
      return 'is-invalid';
    }
    return '';

  }

  hasError(err: string){
    var formControl = this.registerForm.get('password');
    if(formControl.hasError(err) || this.registerForm.hasError('containsUsername')){
      return true;
    }
    return false;
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
