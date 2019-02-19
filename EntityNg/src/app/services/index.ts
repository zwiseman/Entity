import { EmployeesService } from './employees.service';
import { PromiseServiceService } from './promise-service.service';

export * from './employees.service';
export * from './promise-service.service';


export const Services = [
    EmployeesService,
    PromiseServiceService
];

