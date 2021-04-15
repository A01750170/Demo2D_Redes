//Configuracion de sequelize
const Sequelize = require('sequelize');
const sequelize = new Sequelize('juegoDummy','sa','Password1234$',{
    dialect: 'mssql',
    dialectOptions:{
        options:{
            useUTC: false,
            dataFirst: 1
        },
    },
    define:{
        timestamps: false,
        freezeTableName:true
    }
});
// Override timezone formatting
Sequelize.DATE.prototype._stringify = function _stringify(date, options) {
  date = this._applyTimezone(date, options);

  // Z here means current timezone, _not_ UTC
  return date.format('YYYY-MM-DD HH:mm:ss.SSS');
};

//export default sequelize;
//exportando el objeto sequelize
module.exports = sequelize;