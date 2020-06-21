import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  // { path: 'register', component:  },
  { path: 'login', component:  LoginComponent},
  // { path: 'orders', component:  },
  // { path: 'meals', component:  },
  // { path: 'addorder', component:  },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
]