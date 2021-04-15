const Jugador = require('../models/jugador');
const path = require('path');
const sequelize = require('../util/database');
exports.postRegistroJugador = (req,res)=>{
    var today = new Date();
    var fecha = today.getFullYear() + "/"+ today.getMonth() + "/" + today.getDay() + " " + today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds() + "." + today.getUTCMilliseconds()
    //Crea un nuevo objeto JSON con el cuerpo datosJSON proviniente del form de Unity
    var object = JSON.parse(req.body.datosJSON);
    console.log(object)
    //Se crea el registro
    console.log(today.toUTCString())
    Jugador.create({
        nombreUsuario: object.nombreUsuario,
        clave: object.clave,
        correo: object.correo,
        fechaRegistro: fecha
    }).then(resultado=>{
        res.send("Registro exitoso")
        })
      .catch(error=>{
          res.send(error)
          console.log(error)
        });
};
exports.postIniciarSesion = (req,res)=>{
    var object = JSON.parse(req.body.datosJSON);
    var usuario = object.nombreUsuario;
    var clave = object.clave;
    Jugador.findAll({
        where:{
            nombreUsuario: usuario,
            clave: clave
        }
    })
    .then(registros=>{
        if (registros.length == 0){
            res.send("failed")
        }else{
            registros.forEach(registro=>{
                if (registro.nombreUsuario == usuario && registro.clave == clave){
                    var today = new Date();
                    var fecha = today.getFullYear() + "/"+ today.getMonth() + "/" + today.getDay() + " " + today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds() + "." + today.getUTCMilliseconds()
                    Jugador.update({fechaInicioJuego: fecha},{
                        where:{
                            nombreUsuario: usuario
                        }
                    });
                    res.send("success")
                }else{
                    res.send("failed")
                }
            });
        }
        
    });
};

exports.postTerminarJuego = (req,res)=>{
    var object = JSON.parse(req.body.datosJSON);
    var usuario = object.nombreUsuario;
    var clave = object.clave;
    var today = new Date();
    var fecha = today.getFullYear() + "/"+ today.getMonth() + "/" + today.getDay() + " " + today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds() + "." + today.getUTCMilliseconds()
    console.log(object);
    Jugador.update({fechaFinalizacionJuego: fecha},{
        where:{
            nombreUsuario: usuario
        }
    }).then(resultado=>{
        res.send("sucess");
    })
    .catch(error=>{
        res.send("failed");
    })  
};