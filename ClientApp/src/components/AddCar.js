import React, {useEffect, useState} from 'react'
import {Button, Form} from 'react-bootstrap'

export default function AddCar({cars,makes}) {
  // const [cars, setCars] = useState([])  
  // const [makes, setMakes] = useState([])
  const initialFormData = Object.freeze({
    id: "",
    name: "",
     makeId: ""
    });
    const [formData, updateFormData] = React.useState(initialFormData);
  // useEffect(() =>{
  //   const getAllCars = async () =>{
  //     const makeResponse = await fetch('https://localhost:5001/CarMake/GetAll')
  //     const makeResult = await makeResponse.json();
  //     setMakes(makeResult.data);
  //     const carResponse = await fetch('https://localhost:5001/CarModel/GetAll');
  //      const carResult = await carResponse.json();
  //      setCars(carResult.data);

  //     }
  //     getAllCars();
  // }, [setMakes])

  const handleChange = (e) => {
    if(e.target.name === "name")
   { updateFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
    console.log(formData)
  }
    else {
      updateFormData({
        ...formData,
        [e.target.name]: Number(e.target.value),
        id:Number(cars.length + 1)
      });
      console.log(formData)
    }
  };

  const handleSubmit = async (e) => {
   e.preventDefault();
    
    console.log(formData);
    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ ...formData })
  };
  const response = await fetch(`https://localhost:5001/CarModel`, requestOptions)
  
    console.log(requestOptions)
  
}

  return (
    <>
  <Form onSubmit={handleSubmit}> 
 
  <Form.Group className="mb-3" >
    <Form.Label>Car Model Name </Form.Label>
    <Form.Control type="text" onChange={handleChange} placeholder="Enter model name" name="name" />
  </Form.Group>

  <Form.Group className="mb-3" >
  <Form.Label>Select a make</Form.Label>
    <Form.Select onChange={handleChange} name="makeId" >
    {makes.map(item => 
        <option key={item.name} value={item.id}>{item.name}</option>
      )}
    </Form.Select>
  </Form.Group>
  <div className="d-grid gap-2">
  <Button variant="primary" size="lg" type="submit">
    Submit
  </Button>
</div>
</Form>
</>
  )
}
