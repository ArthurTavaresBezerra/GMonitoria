import { PageMainProcessoSeletivoComponent } from './page-main-processo-seletivo/page-main-processo-seletivo.component';
import { Routes } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { PageMainCollaboratorComponent } from './page-main-collaborator/page-main-collaborator.component';
import { PageMainStudentComponent } from './page-main-student/page-main-student.component'; 
 
import { AuthGuard } from './auth/auth.guard';
 
export const appRoutes: Routes = [
    { path: 'home',         component: HomeComponent ,canActivate:[AuthGuard] },
    { path: 'collaborator', component: PageMainCollaboratorComponent},
    { path: 'ProcessoSeletivo', component: PageMainProcessoSeletivoComponent},
   
    {
        path: 'register',     component: UserComponent,
        children: [{ path: '', component: SignUpComponent }]
    },
    {
        path: 'login',  component: SignInComponent
    },
    { path : '', redirectTo:'/login', pathMatch : 'full'}, 
    { path: '**', redirectTo:'/login', pathMatch : 'full'} 
    
];