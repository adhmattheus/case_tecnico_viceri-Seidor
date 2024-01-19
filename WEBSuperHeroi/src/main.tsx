import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import { App } from './App.tsx';
import './index.css';
import NewHeroi from './pages/NewHeroi.tsx';
import EditHeroi from './pages/EditHeroi.tsx';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Router>
      <Routes>
        <Route path="/" element={<App />} />
        <Route path="/newHeroi" element={<NewHeroi />} />
        <Route path="/editHeroi" element={<EditHeroi />} />
      </Routes>
    </Router>
  </React.StrictMode>,
);
