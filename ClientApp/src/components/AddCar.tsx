import React from 'react'
import {Button, Form} from 'react-bootstrap'

interface AddCarProps {
  makes: {id:number, name:string}[]
  handleSubmitAddCar: (e: React.FormEvent) => void
  handleChangeAddCar: (e: React.ChangeEvent) => void
}

const AddCar:React.FC<AddCarProps> = ({makes, handleSubmitAddCar, handleChangeAddCar}) =>{

const onSubmit = (e: React.FormEvent) =>{
 handleSubmitAddCar(e)
}

const onChange = (e: React.ChangeEvent) => {
  handleChangeAddCar(e)
}

  return (
    <>
  <Form onSubmit={onSubmit}> 
 
  <Form.Group className="mb-3" >
    <Form.Label>Car Model Name </Form.Label>
    <Form.Control onChange={onChange} placeholder="Enter model name" name="name" />
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


export default AddCar