import { useRef } from "react";

interface Props {
    onSearch: (search: string) => void;
}

const VisitsFilter = ({ onSearch }: Props) => {
    const ref = useRef<HTMLInputElement>(null);

    return (
        <form
            onSubmit={(event) => {
                event.preventDefault();
                if (ref.current) onSearch(ref.current.value);
            }}
        >
            <div className="row mb-3 md-8">
                <div className="col">
                    <input
                        ref={ref}
                        placeholder="Search hostipal or visitor + ENTER"
                        type="text"
                        className="form-control"
                    />
                </div>
            </div>
        </form>
    );
};

export default VisitsFilter;