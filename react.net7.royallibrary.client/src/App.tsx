import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [books, setBooks] = useState([]);

    useEffect(() => {
        fetch('/api/books')
            .then(response => response.json())
            .then(data => setBooks(data));
    }, []);

    return(
        <div>
            <h1>Book List</h1>
            <table>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Author</th>
                        <th>ISBN</th>
                    </tr>
                </thead>
                <tbody>
                    {books.map(book => (
                        <tr key={book.bookId}>
                            <td>{book.title}</td>
                            <td>{`${book.firstName} ${book.lastName}`}</td>
                            <td>{book.isbn}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default App;