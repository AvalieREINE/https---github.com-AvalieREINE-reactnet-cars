import React from 'react'
import {Button, ListGroup} from 'react-bootstrap'

interface CarListProps {
  cars: {id:number, name:string, makeId:number}[]
  deleteCar: (id:number) => void
 
}


const CarList:React.FC<CarListProps> = ({cars, deleteCar}) => {
  const handleDelete = (id:number) => {
    deleteCar(id)
  } 
  return (
    <>
    <ListGroup> 
      {cars.map(item => (
        <div  key={item.id}>
      <ListGroup.Item>   
          {item.name}
          </ListGroup.Item>
          <ListGroup.Item>
          <Button size="sm" onClick={() =>handleDelete(item.id)}>Delete</Button>
          </ListGroup.Item>
      </div>
    ))}
    </ListGroup>
    </>
  )
}
export default CarList