
import React, {useState, useEffect} from 'react'
import {Container, Row, Col} from 'react-bootstrap'
import CarList from './components/CarList'
import EditCar from './components/EditCar'
import AddCar from './components/AddCar'
import './App.css'
 
type cars = {
  id:number
   name:string
   makeId:number
}[]
type makes = {
  id:number
  name:string
}[]

const App:React.FC= () => {
  const [makes, setMakes] = useState<makes>([])
  const [cars, setCars] = useState<cars>([])
  const initialFormData =Object.freeze({
    id: 0,
    name: "",
     makeId: 0
    });
    const [formData, updateFormData] = React.useState(initialFormData);
    const [formDataAddCar, updateFormDataAddCar] = React.useState(initialFormData);
   
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
  }, [setCars, setMakes ])
 
  const deleteCar = async (id: number) => {

    await fetch(`https://localhost:5001/CarModel/${id}`, {method: 'DELETE'}) 
  
      const response = await fetch('https://localhost:5001/CarModel/GetAll');
      const result = await response.json();
      setCars(result.data);
    }
    const handleChange = (e: React.ChangeEvent) => {
      if( (e.target as HTMLInputElement) .name=== "name")
     { updateFormData({
        ...formData,
        [(e.target as HTMLInputElement) .name]: (e.target as HTMLInputElement) .value
      });
    }
      else {
        updateFormData({
          ...formData,
          [(e.target as HTMLInputElement).name]: Number((e.target as HTMLInputElement).value)
        });
      }
    };

    const handleSubmit = async (e:React.FormEvent) => {
      e.preventDefault();
      const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ ...formData })
    };
     await fetch("https://localhost:5001/CarModel", requestOptions)
      const newResponse = await fetch('https://localhost:5001/CarModel/GetAll');
      const result = await newResponse.json();
      setCars(result.data);
    };

    const handleChangeAddCar= (e: React.ChangeEvent) => {
      if((e.target as HTMLInputElement).name === "name")
     { updateFormDataAddCar({
        ...formDataAddCar,
        [(e.target as HTMLInputElement).name]: (e.target as HTMLInputElement).value
      });
    }
      else {
        updateFormDataAddCar({
          ...formDataAddCar,
          [(e.target as HTMLInputElement).name]: Number((e.target as HTMLInputElement).value),
          id:Number(cars.length + 1)
        });
      }
    };
    const handleSubmitAddCar = async (e:React.FormEvent) => {
      e.preventDefault();
       
       const requestOptions = {
         method: 'POST',
         headers: { 'Content-Type': 'application/json' },
         body: JSON.stringify({ ...formDataAddCar })
     };
      await fetch("https://localhost:5001/CarModel", requestOptions)
     
      const newResponse = await fetch('https://localhost:5001/CarModel/GetAll');
      const result = await newResponse.json();
    
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
        <EditCar makes={makes} cars={cars} handleSubmit={handleSubmit} handleChange={handleChange}/>
        </Col>
        <Col>
        <h3>Add A Car </h3>
        <AddCar makes={makes} handleSubmitAddCar={handleSubmitAddCar} handleChangeAddCar={handleChangeAddCar}/>
        </Col>  
      </Row>
    </Container>
  )
}

export default App;

