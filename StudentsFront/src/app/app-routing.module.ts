import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './components/list/list.component';
import { NewComponent } from './components/new/new.component';


const routes: Routes = [
  { path: '', component: ListComponent },
  { path: 'list', component: ListComponent },
  { path: 'new', component: NewComponent },
  { path: 'edit/:id', component: NewComponent },
  { path: '**', component: ListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
