const Sequelize = require('sequelize');
//Traer el objeto sequelize 
const sequelize = require('../util/database');

//Definicion del modelo (tabla)
const Jugador = sequelize.define('jugador',{
    nombreUsuario:{
        type: Sequelize.STRING(15),
        allowNull: false,
        primaryKey: true
    },
    clave:{
        type: Sequelize.STRING(20),
        allowNull: false
    },
    correo:{
        type: Sequelize.STRING(100),
        allowNull: false,
        primaryKey: false
    },
    fechaRegistro:{
        type: Sequelize.DATE,
        allowNull: true,
        primaryKey: false
    },
    fechaInicioJuego:{
        type: Sequelize.DATE,
        allowNull: true,
        primaryKey: false
    },
    fechaFinalizacionJuego:{
        type: Sequelize.DATE,
        allowNull: true,
        primaryKey: false
    }
});

module.exports = Jugador;