import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ProjectsComponent } from './components/projectsdata/projects.component';
import { AddProjectPersonComponent } from './components/AddProjectPerson/AddProjectPerson.component';
import { ProjectPersonListComponent } from './components/ProjectPersonList/projectpersonlist.component';
import { AddProjectComponent } from './components/AddProject/addproject.component';
import { AddPersonComponent } from './components/AddPerson/addperson.component';
import { PeopleComponent } from './components/PersonList/personlist.component';
@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ProjectsComponent,
        AddProjectPersonComponent,
        ProjectPersonListComponent,
        AddProjectComponent,
        AddPersonComponent,
        PeopleComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'projects', component: ProjectsComponent },
            { path: 'AddProjectPerson', component: AddProjectPersonComponent },
            { path: 'ViewProjectPersons', component: ProjectPersonListComponent },
            { path: 'AddProject', component: AddProjectComponent },
            { path: 'AddPerson', component: AddPersonComponent },
            { path: 'people', component: PeopleComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}
