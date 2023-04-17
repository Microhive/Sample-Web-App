import React, { Component } from 'react';

export class FetchAuthors extends Component {
  static displayName = FetchAuthors.name;

  constructor(props) {
    super(props);
    this.state = { authors: [], loading: true };
  }

  componentDidMount() {
    this.populateAuthorsData();
  }

  static renderAuthorsTable(authors) {
    return (
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          {authors.map(author =>
            <tr key={author.authorId}>
              <td>{author.name}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchAuthors.renderAuthorsTable(this.state.authors);

    return (
      <div>
        <h1 id="tableLabel">Authors</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateAuthorsData() {
    const response = await fetch('https://localhost:7289/api/Authors');
    const data = await response.json();
    this.setState({ authors: data, loading: false });
  }
}
