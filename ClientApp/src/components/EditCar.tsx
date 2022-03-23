import React from 'react'
import {Button, Form} from 'react-bootstrap'
interface EditCarProps {
  makes: {id:number, name:string}[]
  cars: {id:number, name:string, makeId:number}[]
  handleSubmit: (e: React.FormEvent) => void
  handleChange: (e: React.ChangeEvent) => void
}
const EditCar:React.FC<EditCarProps> =({cars, makes, handleChange, handleSubmit}) =>{
 
  const onSubmit =  (e: React.FormEvent) =>{
    handleSubmit(e);
    
  }
  const onChange = (e: React.ChangeEvent) => {
    handleChange(e);
  }
 
  return (
    <>
  <Form onSubmit={onSubmit}> 
  <Form.Group className="mb-3"  >
  <Form.Label>Select an existing car to edit</Form.Label>
    <Form.Select  name="id" onChange={onChange} >
    <option>Please select one</option>
      {
      cars.map(item => 
        <option key={item.id} value={item.id}>{item.name}</option>
      )
      
      }
      
    </Form.Select>
  </Form.Group>
  <Form.Group className="mb-3" >
    <Form.Label>Car Model Name </Form.Label>
    <Form.Control type="text" name="name" onChange={onChange} placeholder="Enter model name" />
  </Form.Group>

  <Form.Group className="mb-3" >
  <Form.Label>Select a make</Form.Label>
    <Form.Select onChange={onChange}  name="makeId" >
    <option>Please select one</option>
    {makes.map(item => 
        <option key={item.name} value={item.id}>{item.name}</option>
      )}
    </Form.Select>
  </Form.Group>
  <Form.Group>
  <div className="d-grid gap-2">
  <Button variant="primary" size="lg" type="submit">
    Submit
  </Button>
  </div>
  </Form.Group>

</Form>
</>
  )
}


export default EditCar


