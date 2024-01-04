import { useState, useEffect } from "react";
import visitsService, { VisitListItem } from "../services/visits-service";
import { CanceledError } from "../services/api-client";

const useVisitsListItems = () => {
    const [visits, setVisits] = useState<VisitListItem[]>([]);
    const [error, setError] = useState("");
    const [isLoading, setLoading] = useState(false);

    useEffect(() => {
        setLoading(true);
        const { request, cancel } = visitsService.getAll<VisitListItem>();
        request
            .then((res) => {
                setVisits(res.data);
                setLoading(false);
            })
            .catch((err) => {
                if (err instanceof CanceledError) return;
                setError(err.message);
                setLoading(false);
            });

        return () => cancel();
    }, []);

    return { visits, error, isLoading, setVisits, setError };
};

export default useVisitsListItems;