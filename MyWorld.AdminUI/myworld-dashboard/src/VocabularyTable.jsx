import { useEffect, useState } from "react";
import axios from "axios";
import "./VocabularyTable.css";

export default function VocabularyTable() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios.get("http://localhost:5001/api/Vocabulary")
      .then((res) => setData(res.data))
      .catch((err) => console.error("Fetch error:", err))
      .finally(() => setLoading(false));
  }, []);

  if (loading) return <p>Loading...</p>;

  return (
    <table className="vocab-table">
      <thead>
        <tr>
          <th>Key</th>
          <th>Value</th>
          <th>Created By</th>
          <th>Created At</th>
        </tr>
      </thead>
      <tbody>
        {data.map((item) => (
          <tr key={item.id}>
            <td>{item.key}</td>
            <td>{item.value}</td>
            <td>{item.createdBy}</td>
            <td>{new Date(item.createdAt).toLocaleString()}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
