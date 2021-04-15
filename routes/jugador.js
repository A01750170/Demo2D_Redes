const express = require('express');
const router = express.Router();
//Traer el modelo de Usuario
//const Jugador = require('../models/jugador');
const JugadorController = require('../controllers/jugador')

//Registra un nuevo usuario en la base de datos desde el juego
router.post('/registro',JugadorController.postRegistroJugador);

//Obtiene los datos del usuario cuando inicia sesión
router.post('/iniciarSesion',JugadorController.postIniciarSesion);

//Registra la fecha y hora de cuando termina el juegue
router.post('/FinalizarJuego',JugadorController.postTerminarJuego);
module.exports = router;