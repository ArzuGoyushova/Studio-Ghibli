import './App.css';
import { Routes, Route } from "react-router-dom";
import { Dashboard } from "@/layouts";
import Layout from '@/layouts/client.jsx';

function App() {

  return (
    <Routes>
      <Route path="/dashboard/*" element={<Dashboard />} />
      <Route path="/*" element={<Layout />} />
    </Routes>
  )
}

export default App;
