import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import VisitsList from "./visits-traker/components/VisitsList";
import { Col, Container, Row } from "react-bootstrap";
import useVisitsListItems from "./hooks/useVisitsListItems";
import { useState } from "react";
import VisitsFilter from "./visits-traker/components/VisitsFilter";

function App() {
    const { visits, error, isLoading, setVisits, setError } =
        useVisitsListItems();

    const [searchText, setSearchText] = useState<string>("");

    const visibleVisits = searchText
        ? visits.filter(
            (e) =>
                e.hospitalName.toLowerCase().includes(searchText.toLowerCase()) ||
                e.personFullName.toLowerCase().includes(searchText.toLowerCase())
        )
        : visits;

    if (visits.length === 0)
        return (
            <Container>
                <Row className="justify-content-md-center mb-3">
                    <Col xs lg="1"></Col>
                    <Col md="auto">No visits found!</Col>
                    <Col xs lg="1"></Col>
                </Row>
            </Container>
        );

    return (
        <Container>
            <br></br>
            <Row className="mb-5">
                <Col xs lg="1"></Col>
                <Col md="8">
                    <VisitsFilter
                        onSearch={(value: string) => setSearchText(value)}
                    ></VisitsFilter>
                </Col>
                <Col xs lg="1"></Col>
            </Row>
            <Row>
                <Col xs lg="2"></Col>
                <Col md="auto">
                    <VisitsList
                        visits={visibleVisits}
                        onDelete={(id) => setVisits(visits.filter((e) => e.visitId !== id))}
                    ></VisitsList>
                </Col>
                <Col xs lg="2"></Col>
            </Row>
        </Container>
    );
}

export default App;