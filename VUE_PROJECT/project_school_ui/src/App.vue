<template>
  <div id="app">
    <Nav></Nav>
    <div class="marginPrincipal">
      <AlunosComponent></AlunosComponent>
      <router-view :key="$route.fullPath"></router-view>
    </div>
  </div>
</template>

<script>
import Nav from './components/_nav/NavComponent.vue'

export default {
  name: 'App',
  components: {
    Nav
  }
}
</script>

<style >
@import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");

.marginPrincipal{
  width: 50%;
  margin: auto;
}

#app {
  width: 100%;
}

body {
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}

body, 
html {
  margin: 0;
  height: 100%;
}

.btn-danger {
  font-size: .8em !important;
  background-color: #fa4430;
}
.btn {
  border: 1px solid black;
  padding: 10px 20px;
  cursor: pointer;
  color: white;
  font-size: 1.1em;
  font-weight: bold;

  border-radius: 5px;
  border-bottom: 3px solid black;
}

.btn:hover {
  text-shadow: 1px 1px 1px black;
  margin-top: 3px;
  border-bottom: 1px solid black;
  background-color: rgb(185, 32, 11);
}



table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}

table thead th {
  background-color: rgb(131, 167, 179) !important;
  font-size: 1.2em;
  padding: 10px 0px;
  text-align: center !important;
  margin-bottom: 2px;  
}

table tr td {
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
}

.colPequeno {
  width: 5%;
  text-align: right;
  background-color: rgb(125, 217, 245);
  font-weight: bold;
}

</style>
