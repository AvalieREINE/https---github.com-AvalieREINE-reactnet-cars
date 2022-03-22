
import React, {useState, useEffect} from 'react'
import {Container, Row, Col} from 'react-bootstrap'
import CarList from './components/CarList'
import EditCar from './components/EditCar'
import AddCar from './components/AddCar'
import './App.css'

const App: React.FC = () => {
  const [makes, setMakes] = useState([])
  const [cars, setCars] = useState([])

  useEffect(() =>{
    const getAllCars = async () =>{
      const response = await fetch('https://localhost:5001/CarModel/GetAll');
       const result = await response.json();
       setCars(result.data);
       const makeResponse = await fetch('https://localhost:5001/CarMake/GetAll')
       const makeResult = await makeResponse.json();
       setMakes(makeResult.data);

      }
      getAllCars();
  }, [setCars, setMakes])
  const deleteCar = async (id:number) => {

    await fetch(`https://localhost:5001/CarModel/${id}`, {method: 'DELETE'}) 
  
      const response = await fetch('https://localhost:5001/CarModel/GetAll');
      const result = await response.json();
      setCars(result.data);
    }
  
  
  return (
    <Container>
      <h1 className="title">Car Auction Store </h1>
      <Row className="container">
        
        <Col  lg={3} >
        <h3>All Available Cars </h3>
        <CarList cars={cars} deleteCar={deleteCar}/>
        </Col>
        <Col>
        <h3>Edit A Car</h3>
        <EditCar makes={makes} cars={cars}/>
        </Col>
        
        <Col>
        <h3>Add A Car </h3>
        <AddCar makes={makes} cars={cars} />
        </Col>  
       
      </Row>
    </Container>
  )
}

export default App;

