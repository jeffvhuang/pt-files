﻿/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.3.0.0 (NJsonSchema v10.1.11.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming



export interface IGetCasefileVm {
    id: number;
    name: string;
    created: string;
    patientId: number;
}

export interface ICreateCasefileCommand {
    patientId: number;
    name: string;
}

export interface IUpdateCasefileCommand {
    id: number;
    patientId: number;
    name: string;
}

export interface IGetConsultationBaseVm {
    id: number;
    casefileId: number;
    date: string;
}

export interface IGetConsultationVm extends IGetConsultationBaseVm {
    practitionerId: number;
    subjectiveAssessment: ISubjectiveAssessmentVm;
    objectiveAssessment: IObjectiveAssessmentVm;
    treatments: string;
    plans: string;
}

export interface ISubjectiveAssessmentVm {
    id: number;
    consultationId: number;
    moi: string;
    currentHistory: string;
    bodyChart: string;
    aggravatingFactors: string;
    easingFactors: string;
    vas: number | null;
    pastHistory: string;
    socialHistory: string;
    imaging: string;
    generalHealth: string;
}

export interface IObjectiveAssessmentVm {
    id: number;
    consultationId: number;
    observation: string;
    active: string;
    passive: string;
    resistedIsometric: string;
    functionalTests: string;
    neurologicalTests: string;
    specialTests: string;
    palpation: string;
    additional: string;
}

export interface IUpdateConsultationCommand {
    id: number;
    date: string;
    practitionerId: number;
    casefileId: number;
    subjectiveAssessment: ISubjectiveAssessmentVm | null;
    objectiveAssessment: IObjectiveAssessmentVm | null;
    treatments: string;
    plans: string;
}

export interface ICreateConsultationCommand {
    date: string;
    practitionerId: number;
    casefileId: number;
    subjectiveAssessment: ISubjectiveAssessmentVm;
    objectiveAssessment: IObjectiveAssessmentVm;
    treatments: string;
    plans: string;
}

export interface IGetObjectiveAssessmentVm extends IObjectiveAssessmentVm {
}

export interface IPersonVm {
    id: number;
    honorific: Honorific;
    firstName: string;
    lastName: string;
    dob: string;
    email: string;
    countryCode: string;
    homePhone: string;
    mobilePhone: string;
    gender: Gender;
}

export interface IGetPatientVm extends IPersonVm {
    occupation: string;
}

/** 0 = NoTitle 1 = Mr 2 = Mrs 3 = Miss 4 = Ms 5 = Master 6 = Mx 7 = M 8 = Sir 9 = Madam 10 = Dr 11 = Prof */
export enum Honorific {
    NoTitle = 0,
    Mr = 1,
    Mrs = 2,
    Miss = 3,
    Ms = 4,
    Master = 5,
    Mx = 6,
    M = 7,
    Sir = 8,
    Madam = 9,
    Dr = 10,
    Prof = 11,
}

/** 0 = Male 1 = Female 2 = Other */
export enum Gender {
    Male = 0,
    Female = 1,
    Other = 2,
}

export interface ICreatePatientCommand {
    honorific: Honorific;
    firstName: string;
    lastName: string;
    dob: string;
    email: string;
    countryCode: string;
    homePhone: string;
    mobilePhone: string;
    gender: Gender;
    occupation: string;
}

export interface IUpdatePatientCommand {
    id: number;
    honorific: Honorific;
    firstName: string;
    lastName: string;
    dob: string;
    email: string;
    countryCode: string;
    homePhone: string;
    mobilePhone: string;
    gender: Gender;
    occupation: string;
}

export interface IGetSubjectiveAssessmentVm extends ISubjectiveAssessmentVm {
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}