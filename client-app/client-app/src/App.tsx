import React, { useEffect, useState } from 'react';
import './App.css';
import {Header, List} from 'semantic-ui-react';
import axios from 'axios';

function App() {
  const [activities, setActivity] = useState([]);

  useEffect(() =>
  {
      axios.get('https://localhost:5001/api/activities').then(response =>
      {
        setActivity(response.data);
      })
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content='Events'/>

      <List>
        {activities.map((activity:any) =>(
        <List.Item key={activity.id}>
            {activity.title}
        </List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
