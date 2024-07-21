import React, {useEffect, useState} from "react";
import {useParams} from "react-router-dom";
import toDoService from "../../services/toDoService";
import {ToDoModel} from "../../models/toDoModel";

const TodoDetail = () => {
  const { id } = useParams();
  const [todo, setTodo] = useState<ToDoModel | null>(null);

  useEffect(() => {
    fetchTodo();
  }, [id]);

  const fetchTodo = async () => {
    const response = await toDoService.fetchById(Number(id));
    setTodo(response.data);
  };

  if (!todo) return <div>Loading...</div>;

  return (
    <div className="todo-detail">
      <h1>{todo.title}</h1>
      <p>ID: {todo.id}</p>
      <p>User ID: {todo.userId}</p>
      <p>Status: {todo.completed ? "Tamamlandı" : "Tamamlanmadı"}</p>
    </div>
  );
};

export default TodoDetail;
