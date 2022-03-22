import React, {useEffect, useState} from 'react'
import {Button, ListGroup} from 'react-bootstrap'

export default function CarList({cars, deleteCar}) {
  const handleDelete = (id) => {
    deleteCar(id)
  } 


  return (
    <>
    <ListGroup> 
      {cars.map(item => (
        <div>
       
        <ListGroup.Item key={item.id}>   
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
