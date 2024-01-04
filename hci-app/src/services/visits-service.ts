import create from "./http-service";

export interface VisitListItem {
    visitId: number;
    hospitalName: string;
    personFullName: string;
    documentType: string;
    documentId: string;
    entryDate: string;
    exitDate: string;
    elapsedTime: string;
}

export default create("/visits");
