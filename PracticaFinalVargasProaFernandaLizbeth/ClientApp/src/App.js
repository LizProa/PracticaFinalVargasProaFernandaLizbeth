import { useEffect, useState } from "react"
import { Col, Container, Row, Card, CardHeader, CardBody, Button } from "reactstrap"
import ModalPersona from "./components/ModalPersona"
import TablaPersona from "./components/TablaPersona"

const App = () => {

    const [personas, setPersonas] = useState([])
    const [mostrarModal, setMostrarModal] = useState(false)
    const [editar, setEditar] = useState(null)

    const mostrarPersonas = async () => {

        const response = await fetch("api/persona/Lista");

        if (response.ok) {
            const data = await response.json();
            setPersonas(data)
        } else {
            console.log("Error en los datos de la lista")
        }

    }

    useEffect(() => {
        mostrarPersonas()
    }, [])

    const guardarPersona = async (persona) => {
        persona.isComplete = persona.isComplete == "true" ? true : false;
        const response = await fetch("api/persona/Guardar", {

            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(persona)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            mostrarPersonas();
        }
    }

    const editarPersona = async (persona) => {
        persona.isComplete = persona.isComplete == "true" ? true : false;
        const response = await fetch("api/persona/Editar", {

            method: 'PUT',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(persona)
        })

        if (response.ok) {
            setMostrarModal(!mostrarModal);
            mostrarPersonas();
        }
    }

    const eliminarPersona = async (id) => {

        var respuesta = window.confirm("Desea eliminar la tarea?")

        if (!respuesta) {
            return;
        }

        const response = await fetch("api/persona/Eliminar/" + id, {
            method: 'DELETE'
        })

        if (response.ok) {
            mostrarPersonas();
        }

    }

    return (
        <Container>
            <Row className="mt-5">
                <Col sm="12">
                    <Card>
                        <CardHeader>
                            <h5>Lista de Tareas</h5>
                        </CardHeader>
                        <CardBody>
                            <Button size="sm" color="info" onClick={() => setMostrarModal(!mostrarModal)}>Nueva Tarea</Button>
                            <hr></hr>
                            <TablaPersona data={personas}
                                setEditar={setEditar}
                                mostrarModal={mostrarModal}
                                setMostrarModal={setMostrarModal}
                                eliminarPersona={eliminarPersona}
                            />
                        </CardBody>
                    </Card>
                </Col>
            </Row>
            <ModalPersona
                mostrarModal={mostrarModal}
                setMostrarModal={setMostrarModal}
                guardarPersona={guardarPersona}
                editar={editar}
                setEditar={setEditar}
                editarPersona={editarPersona}
            />
        </Container>
    )
}

export default App;