import { useState } from 'react';
import Login from './components/Login';
import Register from './components/Register';
import Exam from './components/Exam';
import EvaluationHistory from './components/EvaluationHistory';
import './App.css';

// ── Barra de pestañas ────────────────────────────────────────────────────────
function TabBar({ activeTab, onTabChange }) {
  const tabs = [
    { id: 'exam',    label: '📝 Evaluación' },
    { id: 'history', label: '📋 Historial'  },
  ];

  return (
    <div style={{
      display: 'flex',
      borderBottom: '2px solid #e2e8f0',
      background: '#fff',
      padding: '0 8px',
    }}>
      {tabs.map(tab => (
        <button
          key={tab.id}
          id={`tab-${tab.id}`}
          onClick={() => onTabChange(tab.id)}
          style={{
            padding: '13px 22px',
            fontWeight: 700,
            fontSize: '0.9rem',
            border: 'none',
            background: 'transparent',
            cursor: 'pointer',
            color: activeTab === tab.id ? '#6366f1' : '#94a3b8',
            borderBottom: activeTab === tab.id
              ? '2px solid #6366f1'
              : '2px solid transparent',
            marginBottom: '-2px',
            transition: 'color 0.2s, border-color 0.2s',
          }}
        >
          {tab.label}
        </button>
      ))}
    </div>
  );
}

// ── App principal ────────────────────────────────────────────────────────────
function App() {
  const [page, setPage] = useState('login'); // 'login' | 'register' | 'app'
  const [user, setUser] = useState(null);
  const [tab,  setTab]  = useState('exam');  // 'exam' | 'history'

  const handleLogin = (userData) => {
    setUser(userData);
    setTab('exam');
    setPage('app');
  };

  const handleLogout = () => {
    setUser(null);
    setTab('exam');
    setPage('login');
  };

  return (
    <div className="app-wrapper">

      {/* ── Pantallas de autenticación ── */}
      {page === 'login' && (
        <Login onLogin={handleLogin} onGoToRegister={() => setPage('register')} />
      )}
      {page === 'register' && (
        <Register
          onRegistered={() => setPage('login')}
          onGoToLogin={() => setPage('login')}
        />
      )}

      {/* ── Pantalla principal (post-login) ── */}
      {page === 'app' && user && (
        <div>
          <TabBar activeTab={tab} onTabChange={setTab} />

          <div style={{ paddingTop: '20px' }}>
            {/* Exam siempre montado para no perder el estado del cuestionario
                al cambiar de pestaña — solo se oculta visualmente */}
            <div style={{ display: tab === 'exam' ? 'block' : 'none' }}>
              <Exam user={user} onLogout={handleLogout} />
            </div>

            {/* Historial se renderiza solo cuando está visible */}
            {tab === 'history' && (
              <EvaluationHistory user={user} />
            )}
          </div>
        </div>
      )}
    </div>
  );
}

export default App;
