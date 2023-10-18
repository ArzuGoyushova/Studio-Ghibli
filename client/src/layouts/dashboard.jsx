import { Routes, Route } from "react-router-dom";
import { Cog6ToothIcon } from "@heroicons/react/24/solid";
import { IconButton } from "@material-tailwind/react";
import {
  Sidenav,
  DashboardNavbar,
  Configurator,
  Footer,
} from "@/widgets/layout";
import routes from "@/routes";
import { useMaterialTailwindController, setOpenConfigurator } from "@/context";
import { useState, useEffect } from "react";
import jwtDecode from "jwt-decode";
import NotAuthorized from "@/components/admin/NotAuthorized";

export function Dashboard() {
  const [controller, dispatch] = useMaterialTailwindController();
  const { sidenavType } = controller;
  const [userRole, setUserRole] = useState("");

  useEffect(() => {
    const token = localStorage.getItem('authToken');
    const decodedToken = jwtDecode(token);
    const decodedRole = decodedToken.role;
    setUserRole(decodedRole);
  }, []); 

  return (
    <div className="min-h-screen bg-blue-gray-50/50">
      <Sidenav
        routes={routes}
        brandImg={
          sidenavType === "dark" ? "./img/whiteLogo.png" : "./img/logo.png"
        }
      />
      <div className="p-4 xl:ml-80">
        <DashboardNavbar />
        <Configurator />
        <IconButton
          size="lg"
          color="white"
          className="fixed bottom-8 right-8 z-40 rounded-full shadow-blue-gray-900/10"
          ripple={false}
          onClick={() => setOpenConfigurator(dispatch, true)}
        >
          <Cog6ToothIcon className="h-5 w-5" />
        </IconButton>
        <Routes>
          {routes.map(
            ({ layout, pages }) =>
              layout === "dashboard" &&
              pages.map(({ path, element, allowedRoles }) => (
                allowedRoles && allowedRoles.includes(userRole) ? (
                  <Route key={path} exact path={path} element={element} />
                ) : (
                  <Route key={path} exact path={path} element={<NotAuthorized />} />
                )
              ))
          )}
        </Routes>
        <div className="text-blue-gray-600">
          <Footer />
        </div>
      </div>
    </div>
  );
}

Dashboard.displayName = "./src/layout/dashboard.jsx";

export default Dashboard;
