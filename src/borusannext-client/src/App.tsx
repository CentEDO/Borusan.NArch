import { BrowserRouter, Route, Routes } from "react-router-dom";
import Header from "./components/Header/Header";
import Login from "./pages/Login/Login";
import Homepage from "./pages/HomePage/Homepage";
import TodoDetail from "./pages/Detail/ToDoDetail";

const App = () => {
  return (
    <>
      <BrowserRouter>
        <Header />
        <Routes>
          <Route path="" element={<Homepage />} />
          <Route path="/login" element={<Login />} />
          <Route path="/todo/:id" element={<TodoDetail />} /> {/* Yeni rota */}
        </Routes>
      </BrowserRouter>
    </>
  );
};

export default App;
