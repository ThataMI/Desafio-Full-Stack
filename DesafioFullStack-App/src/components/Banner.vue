<template>
    <div id="main-banner">
      <h1>Bem vindo!</h1>
      <div>
        <router-link to="/company"><button class="submit-btn" type="button" >
          Cadastrar Empresa
        </button></router-link>
        <router-link to="/supplier"><button class="submit-btn" type="button" >
          Cadastrar Fornecedor
        </button></router-link> 
        
        
    </div>
    </div>
   
  </template>
  
  <script>
    export default {
      name: "Banner"
    }
  </script>
  
  <style scoped>
  
    #main-banner {
      background-image: url('/public/img/home-image.png');
      background-position: 0 -250px;
      background-size: cover;
      height: 500px;
      display: flex;
      align-items: center;
      justify-content: flex-start;
    }
  
    #main-banner h1 {
      color: #FFF;
      text-align: center;
      font-size: 60px;
      background-color: #222;
      padding: 20px 40px;
    }
  
    .submit-btn {
  background-color: #222;
  color: #987bad;
  font-weight: bold;
  border: 2px solid #222;
  padding: 10px ;
  margin-top: 200px;
  margin-left: 200px;
  font-size: 16px;
  cursor: pointer;
  transition: 0.5s;
}
  </style>