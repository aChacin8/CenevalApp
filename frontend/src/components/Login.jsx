import { useState } from 'react';
import { api } from '../services/api';

export default function Login({ onLogin, onGoToRegister }) {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setLoading(true);
    try {
      const data = await api.login(username, password);
      onLogin(data);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="auth-container">
      <div className="card auth-card shadow">
        <div className="card-body p-4">
          <div className="text-center mb-4">
            <div className="auth-icon mb-3">
              <i className="bi bi-mortarboard-fill"></i>
            </div>
            <h2 className="card-title fw-bold">CenevalApp</h2>
            <p className="text-muted">Inicia sesión para continuar</p>
          </div>

          {error && (
            <div className="alert alert-danger d-flex align-items-center py-2" role="alert">
              <i className="bi bi-exclamation-triangle-fill me-2"></i>
              <span>{error}</span>
            </div>
          )}

          <form onSubmit={handleSubmit}>
            <div className="mb-3">
              <label htmlFor="login-username" className="form-label fw-semibold">
                <i className="bi bi-person me-1"></i>Usuario
              </label>
              <input
                id="login-username"
                type="text"
                className="form-control"
                placeholder="Ingresa tu usuario"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
                autoFocus
              />
            </div>
            <div className="mb-4">
              <label htmlFor="login-password" className="form-label fw-semibold">
                <i className="bi bi-lock me-1"></i>Contraseña
              </label>
              <input
                id="login-password"
                type="password"
                className="form-control"
                placeholder="Ingresa tu contraseña"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
            </div>
            <button
              type="submit"
              className="btn btn-primary w-100 fw-semibold py-2"
              disabled={loading}
            >
              {loading ? (
                <>
                  <span className="spinner-border spinner-border-sm me-2"></span>
                  Ingresando...
                </>
              ) : (
                <>
                  <i className="bi bi-box-arrow-in-right me-2"></i>
                  Iniciar Sesión
                </>
              )}
            </button>
          </form>

          <hr className="my-4" />
          <p className="text-center mb-0">
            ¿No tienes cuenta?{' '}
            <button className="btn btn-link p-0 fw-semibold" onClick={onGoToRegister}>
              Regístrate aquí
            </button>
          </p>
        </div>
      </div>
    </div>
  );
}
