import { Component } from '@angular/core';
import { Http } from '@angular/http';
@Component({
    selector: 'projects',
    template: require('./projects.component.html')

})
export class ProjectsComponent {
    public project: Projects[];
    constructor(http : Http) {
        http.get('api/ProjectsData/GetProjectsList').subscribe(result => {
          //  debugger;
            this.project = result.json() as Projects[];
        });
//        this.project = { ProjectID: 1, ProjectName: "Sample Project 1", ProjectDesc : "This is sample project" };
    }
}
interface Projects
{
    projectID: number;
    projectName: string;
    projectDesc: string;
    

}