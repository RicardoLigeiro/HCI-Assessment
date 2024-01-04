import { VisitListItem } from "../../services/visits-service";

interface Props {
    visits: VisitListItem[];
    onDelete: (id: number) => void;
}

/*
    we are not going to implement delete just to keep it simple
*/

const VisitsList = ({ visits, onDelete }: Props) => {
    return (
        <table className="table table-bordered">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Hospital</th>
                    <th>Visitor</th>
                    <th>Document Type</th>
                    <th>Document Id</th>
                    <th>Entry Date</th>
                    <th>Exit Date</th>
                    <th>Duration</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {visits.map(visit => <tr key={visit.visitId}>
                    <td>{visit.visitId}</td>
                    <td>{visit.hospitalName}</td>
                    <td>{visit.personFullName}</td>
                    <td>{visit.documentType}</td>
                    <td>{visit.documentId}</td>
                    <td>{visit.entryDate}</td>
                    <td>{visit.exitDate}</td>
                    <td>{visit.elapsedTime}</td>
                    <td>
                        <button className="btn btn-outline-danger" onClick={() => onDelete(visit.visitId)}>Delete</button>
                    </td>
                </tr>)}
            </tbody>
            <tfoot>
                <tr>
                    <td></td>
                    <td colSpan={8}>Total Visits: {visits.length}</td>
                </tr>
            </tfoot>
        </table>
    )
}

export default VisitsList