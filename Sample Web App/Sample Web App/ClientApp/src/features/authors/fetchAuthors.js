import React, { useState, useEffect } from 'react';

export function FetchAuthors() {
  const [authors, setAuthors] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    populateAuthorsData();
  }, []);

  function renderAuthorsTable(authors) {
    return (
        <table className="table table-striped" aria-labelledby="tableLabel">
          <thead>
          <tr>
            <th>Name</th>
          </tr>
          </thead>
          <tbody>
          {authors.map(author => (
              <tr key={author.authorId}>
                <td>{author.name}</td>
              </tr>
          ))}
          </tbody>
        </table>
    );
  }

  async function populateAuthorsData() {
    const response = await fetch('https://localhost:7289/api/Authors');
    const data = await response.json();
    setAuthors(data);
    setLoading(false);
  }

  let contents = loading ? (
      <p>
        <em>Loading...</em>
      </p>
  ) : (
      renderAuthorsTable(authors)
  );

  return (
      <div>
        <h1 id="tableLabel">Authors</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
  );
}