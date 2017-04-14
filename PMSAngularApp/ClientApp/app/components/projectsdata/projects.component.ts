import { Component } from '@angular/core'
@Component({
    selector: 'projects',
    template: require('./projects.component.html')

})
export class ProjectsComponent {
    public project: Projects;
    constructor() {
        this.project = { ProjectID: 1, ProjectName: "Sample Project 1", ProjectDesc : "This is sample project" };
    }
}
interface Projects
{
    ProjectName: string;
    ProjectDesc: string;
    ProjectID: number;

}